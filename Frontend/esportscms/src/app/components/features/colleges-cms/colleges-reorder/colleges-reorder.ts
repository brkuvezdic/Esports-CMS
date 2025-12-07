import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { CollegesService } from '../../../../services/colleges';
import { College } from '../../../../models/college';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-colleges-reorder',
  imports: [DragDropModule,CommonModule, RouterModule],
  templateUrl: './colleges-reorder.html',
  styleUrl: './colleges-reorder.css',
})
export class CollegesReorder implements OnInit {
colleges: College[] = [];
  get isHidden(): boolean {
    return this.router.url !== '/Cms/Colleges';
  }
  constructor(private collegeService: CollegesService,    
     private router: Router,
) {}

  ngOnInit(): void {
    this.loadColleges();
  }

  loadColleges() {
    this.collegeService.getColleges().subscribe(res => {
      this.colleges = res.sort((a, b) => a.sequence - b.sequence);
    });
  }

  drop(event: CdkDragDrop<College[]>) {
    moveItemInArray(this.colleges, event.previousIndex, event.currentIndex);

    const reorderPayload = this.colleges.map((c, index) => ({
      collegeId: c.collegeId,
      sequence: index + 1
    }));

    this.collegeService.reorderColleges(reorderPayload).subscribe();
}
}