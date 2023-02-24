import { Component, OnInit } from '@angular/core';
import { HttpService } from "../Services/http.service";
import { IWeatherForecast } from "../Interfaces/iweather-forecast";
@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.scss']
})
export class WeatherForecastComponent implements OnInit {


  public forecasts?: IWeatherForecast[];

  constructor(http: HttpService) {
    http.GetWeatherForecast()
      .subscribe(forecasts => {
        this.forecasts = forecasts;
      }, error => console.error(error));;
  }

  ngOnInit(): void {
  }

}
