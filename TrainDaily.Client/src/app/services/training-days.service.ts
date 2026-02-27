import { ChangeDetectorRef, Injectable, inject } from '@angular/core';
import { TrainingDayInfos, TrainingInfos, TrainingStatus } from '../types/trainingDayInfo';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

export const testTrainingData: TrainingDayInfos = [
  {
    date: new Date(2026, 1, 1), // 1 февраля 2026
    trainings: [
      {
        id: 1,
        title: 'Бег',
        durationTimeInMinutes: 30,
        description: 'Утро',
        status: TrainingStatus.NotCompleted,
      },
    ],
  },
  {
    date: new Date(2026, 1, 3),
    trainings: [
      {
        id: 2,
        title: 'Йога',
        durationTimeInMinutes: 45,
        description: 'Вечер',
        status: TrainingStatus.Completed,
      },
      {
        id: 3,
        title: 'Растяжка',
        durationTimeInMinutes: 15,
        description: 'Зарядка',
        status: TrainingStatus.Completed,
      },
      {
        id: 4,
        title: 'Растяжка',
        durationTimeInMinutes: 15,
        description: 'Зарядка',
        status: TrainingStatus.Completed,
      },
      {
        id: 5,
        title: 'Растяжка',
        durationTimeInMinutes: 15,
        description: 'Зарядка',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 5),
    trainings: [
      {
        id: 6,
        title: 'Силовая',
        durationTimeInMinutes: 50,
        description: 'Ноги',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 8),
    trainings: [
      {
        id: 7,
        title: 'Плавание',
        durationTimeInMinutes: 40,
        description: 'Бассейн',
        status: TrainingStatus.Completed,
      },
      {
        id: 8,
        title: 'Сауна',
        durationTimeInMinutes: 20,
        description: 'Отдых',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 10),
    trainings: [
      {
        id: 9,
        title: 'Кроссфит',
        durationTimeInMinutes: 60,
        description: 'Интенсив',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 12),
    trainings: [
      {
        id: 10,
        title: 'Вело',
        durationTimeInMinutes: 90,
        description: 'Маршрут',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 15),
    trainings: [
      {
        id: 11,
        title: 'Бег',
        durationTimeInMinutes: 25,
        description: 'Интервалы',
        status: TrainingStatus.Completed,
      },
      {
        id: 12,
        title: 'Растяжка',
        durationTimeInMinutes: 10,
        description: 'Заминка',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 18),
    trainings: [
      {
        id: 13,
        title: 'Йога',
        durationTimeInMinutes: 60,
        description: 'Хатха',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 22),
    trainings: [
      {
        id: 14,
        title: 'Силовая',
        durationTimeInMinutes: 45,
        description: 'Руки',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 1, 25),
    trainings: [
      {
        id: 15,
        title: 'Пилатес',
        durationTimeInMinutes: 55,
        description: 'Кор',
        status: TrainingStatus.Completed,
      },
      {
        id: 15,
        title: 'Бег',
        durationTimeInMinutes: 20,
        description: 'Разминка',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 2, 2), // 2 марта 2026
    trainings: [
      {
        id: 15,
        title: 'Плавание',
        durationTimeInMinutes: 35,
        description: 'Кроль',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 2, 5),
    trainings: [
      {
        id: 15,
        title: 'Бег',
        durationTimeInMinutes: 40,
        description: 'Парк',
        status: TrainingStatus.Completed,
      },
      {
        id: 15,
        title: 'Йога',
        durationTimeInMinutes: 30,
        description: 'Ночь',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 2, 9),
    trainings: [
      {
        id: 15,
        title: 'Кроссфит',
        durationTimeInMinutes: 50,
        description: 'WOD',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 2, 12),
    trainings: [
      {
        id: 15,
        title: 'Вело',
        durationTimeInMinutes: 120,
        description: 'Шоссе',
        status: TrainingStatus.Completed,
      },
    ],
  },
  {
    date: new Date(2026, 2, 15),
    trainings: [
      {
        id: 15,
        title: 'Силовая',
        durationTimeInMinutes: 40,
        description: 'Грудь',
        status: TrainingStatus.Completed,
      },
      {
        id: 15,
        title: 'Растяжка',
        durationTimeInMinutes: 15,
        description: 'Шпагат',
        status: TrainingStatus.Completed,
      },
    ],
  },
];

@Injectable({
  providedIn: 'root',
})
export class TrainingDaysService {
  private trainingsSubject = new BehaviorSubject<TrainingDayInfos>([]);

  http = inject(HttpClient);

  trainingsData$: Observable<TrainingDayInfos> = this.trainingsSubject.asObservable();

  getTrainings(monthAndYear: Date) {
    //todo api get
    const getResult = testTrainingData.filter(
      x =>
        x.date.getMonth() == monthAndYear.getMonth() &&
        x.date.getFullYear() === monthAndYear.getFullYear(),
    );
    this.trainingsSubject.next(getResult);
  }

  getAllTrainingTypes() {
    this.http.get<TrainingInfos>('api/training/getalltypes').subscribe({
      next: result => {
        return result;
      },
      error: console.error,
    });
  }

  setNewStatus(id: number, status: TrainingStatus, date: Date) {
    //todo api put
    const current = this.trainingsSubject.getValue();

    const updated = current.map(day => {
      if (!this.isSameDate(day.date, date)) return day;

      return {
        ...day,
        trainings: day.trainings.map(t => (t.id === id ? { ...t, status } : t)),
      };
    });
    this.trainingsSubject.next(updated);
  }

  addNewTraining(date: Date, trainingId: number) {
    //todo post
  }

  private isSameDate(date1: Date, date2: Date): boolean {
    return date1.toDateString() === date2.toDateString();
  }
}
