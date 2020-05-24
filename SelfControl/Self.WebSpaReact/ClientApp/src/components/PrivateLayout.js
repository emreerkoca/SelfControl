import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { PrivateNavMenu } from './PrivateNavMenu';


export class PrivateLayout extends Component {
  static displayName = PrivateLayout.name;

  render () {
    return (
      <div>
         <PrivateNavMenu />
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
