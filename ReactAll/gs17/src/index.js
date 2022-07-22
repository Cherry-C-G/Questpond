import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import {App,Home,About,Contact} from './App';
import registerServiceWorker from './registerServiceWorker';
import { Router, Route, Link } from 'react-router'


ReactDOM.render((
   <Router>
      <Route path = "/" component = {App}>
       
         <Route path = "home" component = {Home} />
         <Route path = "about" component = {About} />
         <Route path = "contact" component = {Contact} />
      </Route>
   </Router>
), document.getElementById('root'))
registerServiceWorker();
