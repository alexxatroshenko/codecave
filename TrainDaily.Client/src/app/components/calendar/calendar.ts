import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { TrainingDayInfo, TrainingDayInfos, TrainingInfos } from '../../types/trainingDayInfo';
import { DatePipe } from '@angular/common';
import { DayDashboard } from '../day-dashboard/day-dashboard';
import { TrainingDaysService } from '../../services/training-days.service';
import { AddTraining } from '../add-training/add-training/add-training';

@Component({
  selector: 'app-calendar',
  imports: [DatePipe, DayDashboard, AddTraining],
  templateUrl: './calendar.html',
  styleUrl: './calendar.css',
})
export class Calendar implements OnInit {
  trainingService = inject(TrainingDaysService);
  cdr = inject(ChangeDetectorRef);

  trainingData: TrainingDayInfos = [];

  today: Date = new Date();

  choosenTrainingDayInfos: TrainingDayInfo | undefined;

  currentMonthAndYearStringInfo: string = this.today.toLocaleString('ru-RU', {
    month: 'long',
    year: 'numeric',
  });

  dayToAddTraining: Date | null = null;
  currentMonthAndYearInfo: Date = this.today;

  calendarWeeks: (TrainingDayInfo | null)[][] = Array(6)
    .fill(null)
    .map(() => Array(7).fill(null));

  ngOnInit(): void {
    this.trainingService.getTrainings(new Date());
    this.trainingService.trainingsData$.subscribe(data => {
      this.trainingData = data;
      this.buildCalendar();
      this.cdr.markForCheck();
    });
  }

  buildCalendar(): void {
    const firstDayOfMonth = new Date(
      this.currentMonthAndYearInfo.getFullYear(),
      this.currentMonthAndYearInfo.getMonth(),
      1,
    );
    const lastDayOfMonth = new Date(
      this.currentMonthAndYearInfo.getFullYear(),
      this.currentMonthAndYearInfo.getMonth() + 1,
      0,
    );

    let firstDayWeekday = firstDayOfMonth.getDay();

    firstDayWeekday = firstDayWeekday === 0 ? 6 : firstDayWeekday - 1;

    const totalDays = lastDayOfMonth.getDate();
    let currentDay = 1;

    for (let week = 0; week < 6; week++) {
      for (let weekday = 0; weekday < 7; weekday++) {
        if (week === 0 && weekday < firstDayWeekday) {
          this.calendarWeeks[week][weekday] = null;
        } else if (currentDay <= totalDays) {
          const currentDate = new Date(
            this.currentMonthAndYearInfo.getFullYear(),
            this.currentMonthAndYearInfo.getMonth(),
            currentDay,
          );

          const trainingDay = this.trainingData.find(item => item.date.getDate() === currentDay);

          this.calendarWeeks[week][weekday] = trainingDay || {
            date: currentDate,
            trainings: [],
          };

          currentDay++;
        } else {
          this.calendarWeeks[week][weekday] = null;
        }
      }
    }
  }

  openChoosenDayInfo(day: TrainingDayInfo | null): void {
    this.closeAllMenus();
    if (day) this.choosenTrainingDayInfos = day;
  }

  openAddTraining(date: Date): void {
    this.closeAllMenus();
    this.dayToAddTraining = date;
  }

  closeAllMenus(): void {
    this.choosenTrainingDayInfos = undefined;
    this.dayToAddTraining = null;
  }

  getPreviousMonth() {
    this.changeMonth(-1);
  }

  getNextMonth() {
    this.changeMonth(1);
  }

  changeMonth(offset: number) {
    this.currentMonthAndYearInfo = new Date(
      this.currentMonthAndYearInfo.getFullYear(),
      this.currentMonthAndYearInfo.getMonth() + offset,
      1,
    );

    this.currentMonthAndYearStringInfo = this.currentMonthAndYearInfo.toLocaleString('ru-RU', {
      month: 'long',
      year: 'numeric',
    });

    this.trainingService.getTrainings(this.currentMonthAndYearInfo);
  }
}
