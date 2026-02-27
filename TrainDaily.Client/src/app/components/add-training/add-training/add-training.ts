import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-add-training',
  imports: [],
  templateUrl: './add-training.html',
  styleUrl: './add-training.css',
})
export class AddTraining {
  @Input() trainingDay: Date | null = null;
}
