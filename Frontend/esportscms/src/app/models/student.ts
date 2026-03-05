export interface StudentModel {
  id: string;
  username: string;
  role: string;
  selectedRoleId?: number | null;
  collegeId?: number | null;
}


export interface RoleModel {
  id: number;
  roleName: string;
}