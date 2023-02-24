import { Component } from "@angular/core";
import { HttpService } from "../Services/http.service";
import { IUser } from "../Interfaces/iuser";
import { DataService } from "../Services/data.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"]
})
export class LoginComponent {

  public Name = "";
  public Password = "";
  public User?: IUser;
  public ErrorMessage: string | undefined;
  public Loading = false;

  constructor(
    private readonly _httpService: HttpService,
    private readonly _dataService: DataService
  ) { }

  public OnLoginPressed() {
    this.Loading = true;

    this._httpService.Login(this.Name, this.Password)
      .subscribe(user => {
        this.Loading = false;
        this.User = user;
        this._dataService.ChangeUser(user);
        },
        error => {
          this.Loading = false;
          console.log(error);
          this.ErrorMessage = error.message;
        });
  }

}
