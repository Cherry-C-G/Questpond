var hotels = {
      resorts: ["Kirkwood","Squaw","Alpine","Heavenly","Northstar"],
      print: function(delay=1000) {

        setTimeout(function() {
          console.log(this.resorts.join(","))
        }, delay)

      }
    }

    hotels.print()