import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

import AuthService from '../services/auth.service';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.setAuthenticationState = this.setAuthenticationState.bind(this);
    this.logOut = this.logOut.bind(this);
    this.state = {
      collapsed: true,
      authenticationState: false
    };
  }

  componentDidMount() {
    this.setAuthenticationState();
  }

  setAuthenticationState() {
    var userToken = this.getAuthenticationInfo();

    this.setState({
      authenticationState: userToken ? true : false
    });
  }

  getAuthenticationInfo() {
    return AuthService.checkAuthentication();
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  logOut () {
    AuthService.logout();

    this.setAuthenticationState();
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Learn a Language</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                {
                  this.state.authenticationState &&
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/add-word">Add Word</NavLink>
                    </NavItem>
                }
                {
                  this.state.authenticationState &&
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/get-words">My Vocabulary</NavLink>
                    </NavItem>
                }
                {
                  !this.state.authenticationState &&
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                    </NavItem>
                }
                {
                  !this.state.authenticationState &&
                    <NavItem>
                      <NavLink tag={Link} className="text-dark" to="/register">Sign Up</NavLink>
                    </NavItem>
                }
                {
                  this.state.authenticationState &&
                    <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/" onClick={this.logOut}>Logout</NavLink>
                    </NavItem>
                }
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
