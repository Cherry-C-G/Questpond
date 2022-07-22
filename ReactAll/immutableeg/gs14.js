const { Map, Seq } = require('immutable');
const oddSquares = Seq([ 1, 2, 3, 4, 5, 6, 7, 8 ])
  .filter(x => x % 2 !== 0)
  .map(x => x * x)
 console.log(oddSquares.get(1))
 
 
const map = Map({ a: 1, b: 2, c: 3 });
const lazySeq = Seq(map);
const d = lazySeq
  //.flip()
  .map((v,key) => console.log(v,key))
  //.flip()
  
  d.keySeq().forEach(k => console.log(k))
  
  /*
  .flip();*/

 
 /*
 
 
 const { Range } = require('immutable');
Range(1, Infinity)
  .skip(1000)
  .map(n => -n)
  .filter(n => n % 2 === 0)
  .take(2)
  .reduce((r, n) => r * n, 1);
  
  */