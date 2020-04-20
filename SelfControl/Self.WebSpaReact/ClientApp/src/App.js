import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { GetWords } from './components/GetWords';
import { Counter } from './components/Counter';
import { AddWord } from './components/AddWord';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/add-word' component={AddWord} />
        <Route path='/get-words' component={GetWords} />
      </Layout>
    );
  }
}
