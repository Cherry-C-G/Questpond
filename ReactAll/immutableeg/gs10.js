const obj1 = { a: 1, b: 2, c: 3 };
const obj2 = { a: 1, b: 2, c: 3 };
console.log(obj1 !== obj2); // two different instances are always not equal with ===

const { Map, is } = require('immutable');
const map1 = Map({ a: 1, b: 2, c: 3 });
const map2 = Map({ a: 1, b: 2, c: 3 });
console.log(map1 !== map2); // two different instances are not reference-equal
console.log(map1.equals(map2)); // but are value-equal if they have the same values
console.log(is(map1, map2)); // alternatively can use the is() function