const { fromJS } = require('immutable');

const obj = { 1: "one" };
console.log(Object.keys(obj)); // [ "1" ]
console.log(obj["1"], obj[1]); // "one", "one"

const map = fromJS(obj);
console.log(map.get("1"), map.get(1)); 