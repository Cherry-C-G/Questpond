const RaceDayService = superclass => class extends superclass { 
    constructor(){
        super();
        console.log('service');
    }
}

const RaceDayDB = superclass => class extends superclass { 
    constructor(){
        super();
        console.log('db');
    }
}

class RaceDayUI {
    constructor(){
        console.log('ui');
    }
}

class RaceDay extends RaceDayDB(RaceDayService(RaceDayUI)){
    constructor(options){
        super();
        console.log('main');
    }
}

const raceDay = new RaceDay();

