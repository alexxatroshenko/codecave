import { ChangeDetectorRef, Component, inject, Input, OnInit } from '@angular/core';
import {
  TrainingDayInfo,
  TrainingDayInfos,
  TrainingInfo,
  TrainingStatus,
} from '../../types/trainingDayInfo';
import { TrainingDaysService } from '../../services/training-days.service';

@Component({
  selector: 'app-day-dashboard',
  imports: [],
  templateUrl: './day-dashboard.html',
  styleUrl: './day-dashboard.css',
})
export class DayDashboard implements OnInit {
  @Input() trainingInfos: TrainingDayInfo | undefined = undefined;
  trainingService = inject(TrainingDaysService);

  ngOnInit(): void {
    this.trainingService.trainingsData$.subscribe(data => {
      this.trainingInfos = data.find(x => x.date === this.trainingInfos?.date);
    });
  }

  changeStatus(training: TrainingInfo) {
    const newStatus =
      training.status === TrainingStatus.Completed
        ? TrainingStatus.NotCompleted
        : TrainingStatus.Completed;

    this.trainingService.setNewStatus(training.id, newStatus, this.trainingInfos?.date!);
  }
}
