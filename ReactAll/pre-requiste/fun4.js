
  var welcome = name => `Welcome ${name}`   
    console.log( welcome("John") )
    console.log( welcome("Jill") )
	
	
	 var greeting = function(msg, name) {
      return `${msg}  ${name}`
    }
	
	console.log(greeting("Hi","Friend"))
	
	 var greetingArrow= (msg, name) =>
       `From single ${msg}  ${name}`
    
	
	console.log(greetingArrow("Hi","Friend"))
