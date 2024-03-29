import {  Routes } from "@angular/router"
import { HomeComponent } from "./Home/Home.component"
import { ListsComponent } from "./Lists/Lists.component"
import { MemberDeatilsComponent } from "./members/member-deatils/member-deatils.component"
import { MemberListComponent } from "./members/Member-list/Member-list.component"
import { MessagesComponent } from "./Messages/Messages.component"
import { AuthGuard } from "./_Guards/auth.guard"

export const AppRoutes : Routes=[
{path:'',component:HomeComponent},
{path:'',runGuardsAndResolvers:'always',
 canActivate:[AuthGuard],
children:[
    {path:'members',component:MemberListComponent },
    {path:'members/:id',component:MemberDeatilsComponent},
    {path:'lists',component:ListsComponent},
    {path:'messages',component:MessagesComponent}

]},
{path:'home',component:HomeComponent},

{path:'**',redirectTo:'home',pathMatch:'full'},

];