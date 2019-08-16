import { RouterModule, Routes }  from '@angular/router';
import { InvestorComponent } from './investor/investor.component';
import { NgModule } from '@angular/core';
import { SuccessComponent } from './success/success.component';

const appRoutes: Routes = [
    { path: 'investor-details', component: InvestorComponent },
    { path: 'success', component: SuccessComponent },
    { path: '',   redirectTo: '/investor-details', pathMatch: 'full' },
    { path: '**', component: InvestorComponent }
];

@NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes
      )
    ],
    exports: [
      RouterModule
    ]
  })
  export class AppRoutingModule {}