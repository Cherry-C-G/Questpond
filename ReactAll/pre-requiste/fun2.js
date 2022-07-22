
 var defaultTrainer = {
      name: {
        first: "Vishwa"
      },
      subject: ["React","Python"]
    }

    function train(p=defaultTrainer) {
      console.log(`${p.name.first} teaches ${p.subject}`)
    }

    train()
 