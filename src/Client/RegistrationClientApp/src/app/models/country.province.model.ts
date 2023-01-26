export class Country{
    constructor(public id:string, public name:string){}
}

export class Province{
    constructor(public id:string, public name:string){}
}

export class UserProvince{
    constructor(public userId:string, public provinceId:string){}
}