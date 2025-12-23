import { Component, OnInit } from '@angular/core';
import { forkJoin } from 'rxjs';
import { StudentModel } from '../../../../models/student';
import { StudentsService } from '../../../../services/students';
import { Router } from '@angular/router';
import { RoleService } from '../../../../services/role';
import { RoleModel } from '../../../../models/role';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-students',
  imports: [FormsModule],
  templateUrl: './students.component.html',
  styleUrl: './students.component.css',
})
export class StudentsComponent implements OnInit {
  students: StudentModel[] = [];
  roles: RoleModel[] = [];
  originalRoleIds: Map<number, number> = new Map();
  isUpdateButtonDisabled = true;

  constructor(
    private studentService: StudentsService,
    private roleService: RoleService,
    private router: Router
  ) { }

  get isHidden(): boolean {
    return this.router.url === '/Cms/Students';
  }

  ngOnInit(): void {
    this.loadAllData();
  }

  getRolesForStudent(student: StudentModel): RoleModel[] {
    if (!student.role || !this.roles.length) {
      return this.roles;
    }

    const currentRole = this.roles.find(r => 
      r.roleName.toLowerCase() === student.role.toLowerCase()
    );

    const otherRoles = this.roles.filter(r => 
      r.roleName.toLowerCase() !== student.role.toLowerCase()
    );

    return currentRole ? [currentRole, ...otherRoles] : this.roles;
  }

  loadAllData(): void {
    forkJoin({
      roles: this.roleService.getRoles(),
      students: this.studentService.getStudents()
    }).subscribe(({ roles, students }) => {
      this.roles = roles;
      
      this.students = students.map(student => {
        const currentRoleId = this.roles.find(r => 
          r.roleName.toLowerCase() === (student.role || '').toLowerCase()
        )?.id;
        
        this.originalRoleIds.set(student.id, currentRoleId || 0);
        
        return {
          ...student,
          selectedRoleId: currentRoleId
        };
      });
      
      this.isUpdateButtonDisabled = true;
    });
  }

  onRoleChange(): void {
    this.isUpdateButtonDisabled = false;
  }

  onUndoChanges(): void {
    this.students = this.students.map(student => ({
      ...student,
      selectedRoleId: this.originalRoleIds.get(student.id) || null
    }));
    this.isUpdateButtonDisabled = true;
  }

  updateRoles(): void {
    const changes: { userId: number; roleId: number }[] = [];
    
    this.students.forEach(student => {
      const originalId = this.originalRoleIds.get(student.id);
      if (student.selectedRoleId && student.selectedRoleId !== originalId) {
        changes.push({
          userId: student.id,
          roleId: student.selectedRoleId!
        });
      }
    });

    if (changes.length > 0) {
      this.studentService.updateStudentRoles(changes).subscribe({
        next: (response) => {
          console.log('Roles updated successfully', response);
          this.loadAllData();
        },
        error: (error) => {
          console.error('Error updating roles', error);
          alert('Failed to update roles');
        }
      });
    }
  }

  getChangedCount(): number {
  return this.students.filter(student => {
    const originalId = this.originalRoleIds.get(student.id);
    return student.selectedRoleId && student.selectedRoleId !== originalId;
  }).length;
}

}
