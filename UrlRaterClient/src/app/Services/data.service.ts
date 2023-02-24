import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { IUser } from "../Interfaces/iuser";

@Injectable({
  providedIn: "root"
})
export class DataService {

  private _userSource = new BehaviorSubject<IUser | undefined>(undefined);
  private _urlSource = new BehaviorSubject<URL | undefined>(undefined);
  private _pageTitleSource = new BehaviorSubject<string>("");

  public CurrentUser = this._userSource.asObservable();
  public CurrentUrl = this._urlSource.asObservable();
  public CurrentPageTitle = this._pageTitleSource.asObservable();

  public ChangeUser(user: IUser) { this._userSource.next(user); }
  public ChangeUrl(url: URL) { this._urlSource.next(url); }
  public ChangePageTitle(pageTitle: string) { this._pageTitleSource.next(pageTitle); }
}
