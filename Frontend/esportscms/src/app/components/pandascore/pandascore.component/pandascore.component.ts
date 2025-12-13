import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PandaScoreModel } from '../../../models/pandaScore';
import { PandaScoreService } from '../../../services/panda-score';
import { CommonModule } from '@angular/common';

@Component({
selector: 'app-pandascore',
  standalone: true,            
  imports: [CommonModule],                 
  templateUrl: './pandascore.component.html',
  styleUrls: ['./pandascore.component.css'], 
})
export class PandascoreComponent {
  pandascoreModel: PandaScoreModel[] = [];

  constructor(private pandascoreService: PandaScoreService, private router: Router) {}

  get isHidden(): boolean {
    return this.router.url === '/UpcomingMatches';
  }

  ngOnInit(): void {
    this.loadPandaScore();
  }

  loadPandaScore() {
    this.pandascoreService.getPandaScoreUpcommingMatches()
      .subscribe(data => {
        this.pandascoreModel = data;
      });
  }
}
