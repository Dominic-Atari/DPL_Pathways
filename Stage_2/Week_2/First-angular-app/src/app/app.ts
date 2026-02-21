import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  title = 'First-angular-app';
  sum1 = 0;

  public myfunction(): number {
    const firstNumber = 10;
    const secondNumber = 20;
    const sum = firstNumber + secondNumber;
    return sum;
  }
}
