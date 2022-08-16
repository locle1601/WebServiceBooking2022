import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'prefix' },

            // {
            //     path: 'dashboard',
            //     loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule)
            // },
            // {
            //     path: 'booking',
            //     loadChildren: () => import('./booking/booking.module').then((m) => m.BookingModule)
            // },

            { path: 'charts', loadChildren: () => import('./charts/charts.module').then((m) => m.ChartsModule) },
            { path: 'forms', loadChildren: () => import('./form/form.module').then((m) => m.FormModule) },

            {
                path: 'bs-element',
                loadChildren: () => import('./bs-element/bs-element.module').then((m) => m.BsElementModule)
            },
            { path: 'grid', loadChildren: () => import('./grid/grid.module').then((m) => m.GridModule) },
            // {
            //     path: 'components',
            //     loadChildren: () => import('./bs-component/bs-component.module').then((m) => m.BsComponentModule)
            // },
            {
                path: 'blank-page',

            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule { }
