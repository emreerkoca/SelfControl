import React, { Component } from 'react';
import { Route } from 'react-router';
import { PublicLayout } from './components/PublicLayout';
import { PrivateLayout } from './components/PrivateLayout';
import { Home } from './components/Home';
import { GetWords } from './components/GetWords';
import { AddWord } from './components/AddWord';
import { Login } from './components/Login';
import { LogOut } from './components/LogOut';
import { Register } from './components/Register';
import { UserBoard } from './components/UserBoard';
import AuthService from './services/AuthService';

import './custom.css';
import 'bootstrap/dist/css/bootstrap.min.css';

export default class App extends Component {
  static displayName = App.name;

  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false
    }

    this.handleLogin = this.handleLogin.bind(this);
    this.handleLogout = this.handleLogout.bind(this);
  }

  checkAuthentication () {
    var isAuthenticated = AuthService.checkAuthentication();

    if (isAuthenticated) {
      this.setState({isAuthenticated: true});
    }
  }

  componentDidMount() {
    this.checkAuthentication();
  }

  handleLogout() { 
    this.setState({
      isAuthenticated: false,
    });
  }

  handleLogin(data) { 
    this.setState({
      isAuthenticated: true
    });
  }

  render () {
    var current = <PublicLayout>
      <Route exact path='/' component={Home} />
      <Route
            exact
            path={"/login"}
            render={props => (
              <Login
                {...props}
                handleLogin={this.handleLogin}
                authenticationState={this.state.authenticationState}
              />
            )}
          />
      <Route path="/register" component={Register} />
    </PublicLayout>;
    
    if (this.state.isAuthenticated) {
      current = <PrivateLayout>
      <Route path='/add-word' component={AddWord} />
      <Route path='/get-words' component={GetWords} />
      <Route path="userboard" component={UserBoard} />
      <Route
            exact
            path={"/logout"}
            render={props => (
              <LogOut
                {...props}
                handleLogout={this.handleLogout}
              />
            )}
          />
    </PrivateLayout>;
    }
     
    return (
      current
    );
  }
}
