import { Component, OnInit } from '@angular/core';
import { College } from '../../models/college';
import { CollegesService } from '../../services/colleges';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-colleges',
  imports: [CommonModule],
  templateUrl: './colleges.html',
  styleUrl: './colleges.css',
})
export class CollegesComponent implements OnInit {
  colleges: College[] = [];

  constructor(private collegeService: CollegesService) {}

  ngOnInit(): void {
    this.loadColleges();
  }

  loadColleges() {
    this.collegeService.getColleges()
      .subscribe(colleges => this.colleges = colleges);
  }
}
