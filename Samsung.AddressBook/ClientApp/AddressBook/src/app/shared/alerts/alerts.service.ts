import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root',
})
export class AlertsService {

    public alerts: { id: number, message: string, expirationDate: Date }[] = [];
    public successAlerts: { id: number, message: string, expirationDate: Date }[] = [];

    constructor() {
        setInterval(() => {
            this.alerts = this.alerts.filter(x => x.expirationDate.getTime() > new Date().getTime());
            this.successAlerts = this.successAlerts.filter(x => x.expirationDate.getTime() > new Date().getTime());
        }, 2000)
    }

    public addAllert(message: string): void {
        this.alerts.push({
            id: new Date().getTime(),
            message: message,
            expirationDate: new Date(new Date().getTime() + 5 * 1000)
        });
    }

    public closeAllert(id: number): void {
        this.alerts = this.alerts.filter(x => x.id !== id);
    }


    public addSuccessAllert(message: string): void {
        this.successAlerts.push({
            id: new Date().getTime(),
            message: message,
            expirationDate: new Date(new Date().getTime() + 5 * 1000)
        });
    }
    public closeSuccessAllert(id: number): void {
        this.successAlerts = this.successAlerts.filter(x => x.id !== id);
    }
}