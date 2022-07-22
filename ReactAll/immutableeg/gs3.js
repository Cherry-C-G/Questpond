const { Map } = require('immutable');
const map = Map({ a: 1, b: 2, c: 3 });
const mapCopy = map;
console.log("===="+(mapCopy === map))
const g =mapCopy.set('d',4)
console.log("===="+(g === map))