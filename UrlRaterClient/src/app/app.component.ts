import { Component, NgZone } from "@angular/core";
import { IUser } from "./Interfaces/iuser";
import { DataService } from "./Services/data.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})

export class AppComponent {

  public title = "UrlRaterClient";
  public PageTitle = "[Title]";
  public UrlName = "";
  public Domain = "";
  public User?: IUser;

  private readonly _userSubscription: Subscription;
  private readonly _urlSubscription: Subscription;

  constructor(
    private readonly _ngZone: NgZone,
    private readonly _dataService: DataService
  ) {
    // ReSharper disable once TsResolvedFromInaccessibleModule
    chrome.runtime.onMessage.addListener(data => console.log(data));
    const dataService = this._dataService;

    this._userSubscription = dataService.CurrentUser.subscribe(user => this.User = user);
    this._urlSubscription = dataService.CurrentUrl.subscribe(url => {
      if (url == undefined)
        return;

      this.UrlName = url.href;
      this.Domain = url.hostname;
    });

  }

  public ngOnInit() {

    // ReSharper disable once TsResolvedFromInaccessibleModule
    chrome.tabs.query({ 'active': true, 'lastFocusedWindow': true }, (tabs) => {
      this._ngZone.run(() => { //basically same as safelyInvoke
        var tab = tabs[0];
        var title = tab.title;
        var urlName = tab.url;

        if (title != undefined) {
          this._dataService.ChangePageTitle(title);
          this.PageTitle = title;
        }

        if (urlName != undefined)
          this._dataService.ChangeUrl(new URL(urlName));
        });
    });
  }
  public ngOnDestroy() {
    this._userSubscription?.unsubscribe();
  }

}
