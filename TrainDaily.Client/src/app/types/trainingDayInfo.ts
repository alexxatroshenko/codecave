export interface TrainingInfo {
  id: number;
  title: string;
  durationTimeInMinutes: number;
  description: string;
  status: TrainingStatus;
}

export interface TrainingDayInfo {
  date: Date;
  trainings: TrainingInfos;
}

export type TrainingInfos = TrainingInfo[];
export type TrainingDayInfos = TrainingDayInfo[];

export enum TrainingStatus {
  Completed = 'Выполнено',
  NotCompleted = 'Не выполнено',
}
