const { Map } = require('immutable');
const alpha = Map({ a: 1, b: 2, c: 3, d: 4 });
alpha.map((v, k) => console.log(k.toUpperCase()));
console.log(alpha)