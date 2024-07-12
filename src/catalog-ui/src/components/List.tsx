import React, { Component, PropsWithChildren } from 'react';
import { Container } from 'reactstrap';

export class List extends Component<PropsWithChildren> {
  static displayName: string = List.name;

  render () {
    return (
      <div>
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}