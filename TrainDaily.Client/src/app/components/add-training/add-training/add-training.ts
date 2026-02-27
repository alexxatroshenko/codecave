import { Component, EventEmitter, Input, Output, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TrainingInfo } from '../../../types/trainingDayInfo';
import { TrainingDaysService } from '../../../services/training-days.service';

@Component({
  selector: 'app-add-training',
  imports: [FormsModule],
  templateUrl: './add-training.html',
  styleUrl: './add-training.css',
})
export class AddTraining implements OnInit {
  @Input() trainingDay: Date | null = null;
  @Output() close = new EventEmitter<void>();

  trainingService = inject(TrainingDaysService);

  trainingTypes: TrainingInfo[] = [];
  selectedTrainingTypeId: number | null = null;

  ngOnInit(): void {
    this.trainingService.trainingTypesData$.subscribe(types => {
      this.trainingTypes = types;
    });
    this.trainingService.getAllTrainingTypes();
  }

  submit(): void {
    if (this.trainingDay && this.selectedTrainingTypeId) {
      this.trainingService.addTraining(this.trainingDay, this.selectedTrainingTypeId);
    }
  }
}

