import { Injectable, inject } from '@angular/core';
import {
  TrainingDayInfos,
  TrainingInfos,
  TrainingInfo,
  TrainingStatus,
} from '../types/trainingDayInfo';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TrainingDaysService {
  private trainingsSubject = new BehaviorSubject<TrainingDayInfos>([]);
  private trainingTypesSubject = new BehaviorSubject<TrainingInfos>([]);

  http = inject(HttpClient);

  trainingsData$: Observable<TrainingDayInfos> = this.trainingsSubject.asObservable();
  trainingTypesData$: Observable<TrainingInfos> = this.trainingTypesSubject.asObservable();

  getTrainings(monthAndYear: Date) {
    this.http
      .get<TrainingDayInfos>(
        `api/training/get-trainings?month=${monthAndYear.getMonth() + 1}&year=${monthAndYear.getFullYear()}`,
      )
      .subscribe({
        next: result => {
          const converted = result.map(day => ({
            ...day,
            date: new Date(day.date),
          }));
          this.trainingsSubject.next(converted);
        },
        error: console.error,
      });
  }

  getAllTrainingTypes() {
    this.http.get<TrainingInfos>('api/training/getalltypes').subscribe({
      next: result => {
        this.trainingTypesSubject.next(result);
      },
      error: console.error,
    });
  }

  addTraining(date: Date, trainingId: number) {
    this.http
      .post<TrainingInfo>('api/training/add', {
        trainingTypeId: trainingId,
        date: this.toDateOnlyString(date),
      })
      .subscribe({
        next: newTraining => {
          const current = this.trainingsSubject.getValue();
          const dateStr = this.toDateOnlyString(date);

          let existingDay = current.find(day => this.toDateOnlyString(day.date) === dateStr);

          if (existingDay) {
            existingDay.trainings.push(newTraining);
          } else {
            existingDay = {
              date: new Date(date),
              trainings: [newTraining],
            };
            current.push(existingDay);
          }

          this.trainingsSubject.next([...current]);
        },
        error: console.error,
      });
  }

  setNewStatus(id: number, status: TrainingStatus, date: Date) {
    const statusId = status === TrainingStatus.Completed ? 1 : 2;

    this.http
      .put(`api/training/update-status`, {
        trainingId: id,
        statusId: statusId,
        date: this.toDateOnlyString(date),
      })
      .subscribe({
        next: () => {
          const current = this.trainingsSubject.getValue();

          const updated = current.map(day => {
            if (!this.isSameDate(day.date, date)) return day;

            return {
              ...day,
              trainings: day.trainings.map(t => (t.id === id ? { ...t, status } : t)),
            };
          });
          this.trainingsSubject.next(updated);
        },
        error: console.error,
      });
  }

  private toDateOnlyString(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  private isSameDate(date1: Date, date2: Date): boolean {
    return date1.toDateString() === date2.toDateString();
  }
}

