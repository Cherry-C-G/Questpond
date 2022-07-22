const 
{ Map } = require('immutable');
const originalMap = Map({ a: 1, b: 2, c: 3 });
const updatedMap = originalMap.set('b', 1000);
// New instance, leaving the original immutable.
console.log(updatedMap !== originalMap);
const anotherUpdatedMap = originalMap.set('b', 1000);
// Despite both the results of the same operation, each created a new reference.
console.log(anotherUpdatedMap !== updatedMap);
// However the two are value equal.
console.log(anotherUpdatedMap.equals(updatedMap));