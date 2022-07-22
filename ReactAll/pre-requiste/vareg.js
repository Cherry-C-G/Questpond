var name = "John"
 console.log('name before', name)
    if (name) {
      var name = "Jack"
      console.log('name in block', name)
    }
//Global variables are also affected
    console.log('name in global', name)