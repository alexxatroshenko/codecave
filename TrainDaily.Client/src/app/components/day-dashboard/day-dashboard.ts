import { Component, inject, Input, OnInit } from '@angular/core';
import {
  TrainingDayInfo,
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
      if (this.trainingInfos?.date) {
        this.trainingInfos = data.find(x => this.isSameDate(x.date, this.trainingInfos!.date!));
      }
    });
  }

  private isSameDate(date1: Date, date2: Date): boolean {
    return date1.toDateString() === date2.toDateString();
  }

  changeStatus(training: TrainingInfo, date: Date) {
    const newStatus =
      training.status === TrainingStatus.Completed
        ? TrainingStatus.NotCompleted
        : TrainingStatus.Completed;

    this.trainingService.setNewStatus(training.id, newStatus, date);
  }
}
