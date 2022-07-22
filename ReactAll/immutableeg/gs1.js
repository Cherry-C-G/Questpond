const { Map } = require('immutable');
const map1 = Map({ a: 1, b: 2, c: 3 });
const map2 = Map({ a: 1, b: 2, c: 3 });
console.log("equals--->"+map1.equals(map2)); // true
console.log("== operator>"+(map1 === map2)); // false