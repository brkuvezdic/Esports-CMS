import { Component, OnInit } from '@angular/core';
import { College } from '../../models/college';
import { CollegesService } from '../../services/colleges';

import { Router } from '@angular/router';

@Component({
  selector: 'app-colleges',
  imports: [],
  templateUrl: './colleges.html',
  styleUrl: './colleges.css',
})
export class CollegesComponent implements OnInit {
  colleges: College[] = [];

  constructor(private collegeService: CollegesService
    ,private router: Router
  ) {}


  get isHidden(): boolean {
    return this.router.url === '/';
  }


  ngOnInit(): void {
    this.loadColleges();
  }

loadColleges() {
  this.collegeService.getColleges()
    .subscribe(colleges => {
      this.colleges = colleges.map(c => ({
        ...c,
        logo: this.getLogo(c.title)
      }));
    });
}

getLogo(title: string): string {
  const t = title.toLowerCase();

  if (t.includes('zagreb') && !t.includes('applied sciences')) {
    return 'app/assets/esports-logo.jpg';
  }

  if (t.includes('rijeka')) {
    return 'app/assets/uniri.png';
  }

  if (t.includes('osijek') || t.includes('strossmayer')) {
    return 'app/assets/ferit.jpg';
  }

  if (t.includes('applied sciences') || t.includes('tvz')) {
    return 'app/app/assets/tvz.jpg';
  }

  if (t.includes('zadar')) {
    return 'app/assets/unizd.png';
  }

  if (t.includes('dubrovnik')) {
    return 'app/assets/unidu.jpg';
  }

  return 'app/assets/esports-logo.jpg';
}


}
