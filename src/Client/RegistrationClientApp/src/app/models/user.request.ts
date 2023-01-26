export class User{
    constructor(public login:Email, public password:Password, public confirmPassword:Password, public isAgreeWorkForFood:boolean){}
}

export class Email{
    constructor(public value:string){}
}

export class Password{
    constructor(public value:string){}
}