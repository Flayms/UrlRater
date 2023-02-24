import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IUser } from "../Interfaces/iuser";
import { IWeatherForecast } from "../Interfaces/iweather-forecast";

@Injectable({
  providedIn: "root"
})
export class HttpService {

  private _url = "https://localhost:44382/";
  private _loginUrl = this._url + "User";
  private _weatherForecastUrl = this._url + "WeatherForecast";

  constructor(private readonly _http: HttpClient) { }

  public Login(name: string, password: string) {
    const params = new HttpParams()
      .set("name", name)
      .set("password", password);

    return this._http.get<IUser>(this._loginUrl, { params });
  }

  public GetWeatherForecast() {
    return this._http.get<IWeatherForecast[]>(this._weatherForecastUrl);
  }
}
