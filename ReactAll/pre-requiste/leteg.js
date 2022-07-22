var name = "John"
 console.log('name before', name)
    if (name) {
      let name = "Jack"
      console.log('name in block', name)
    }
//Global variables are not affected
    console.log('name in global', name) 