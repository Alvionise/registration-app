import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { User } from '../models/user.request';
import { UserProvince } from '../models/country.province.model';

   
@Injectable()
export class RequestService{
    baseUri = 'http://localhost:5050/';
    constructor(private http: HttpClient){ }
 
    createUser(user: User){
        return this.http.post(this.baseUri + "api/users", user); 
    }

    getAllCountries(){
        return this.http.get(this.baseUri + "api/countries");
    }

    getProvincesByCountry(id:string){
        return this.http.get(this.baseUri + "api/provinces/" + id);
    }

    setUserProvince(userProvince: UserProvince){
        return this.http.put(this.baseUri + "api/users", userProvince); 
    }
}