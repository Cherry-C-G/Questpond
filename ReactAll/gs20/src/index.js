import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import {App,Home,About,Contact} from './App';
import registerServiceWorker from './registerServiceWorker';
import { Router, Route, Link, IndexRoute } from 'react-router'


ReactDOM.render((
   <Router>
      <Route path = "/" component = {App}>
         <IndexRoute component = {Home} />
         <Route path = "home" component = {Home} />
         <Route path = "about" component = {About} />
         <Route path = "contact" component = {Contact} />
      </Route>
   </Router>
), document.getElementById('root'))
registerServiceWorker();
