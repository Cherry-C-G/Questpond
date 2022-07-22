const { List } = require('immutable');
const list1 = List([ 1, 2, 3 ]);
const list2 = list1.withMutations(function (list) {
	console.log(list)
  console.log(list.push(4) === list.push(5))
 
  list.push(6);
});

console.log(list1.size)
console.log(list2.size)