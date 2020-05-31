import React, { Component } from 'react';
import { Button } from 'react-bootstrap';

export class AddWord extends Component {
    constructor(props) {
      super(props);
      this.state = { 
        vocable: '',
        meaning: '',
        sentence: '',
        ownerId: 'test@sampledomain.com',
        viewCount: 0
      };

      this.handleSubmit = this.handleSubmit.bind(this);
      this.handleWordChange = this.handleWordChange.bind(this);
      this.handleMeaningChange = this.handleMeaningChange.bind(this);
      this.handleExampleChange = this.handleExampleChange.bind(this);
    }

    handleWordChange(e) {
      this.setState({vocable: e.target.value});
    }
  
    handleMeaningChange(e) {
      this.setState({meaning: e.target.value});
    }

    handleExampleChange(e) {
      this.setState({sentence: e.target.value});
    }

    handleSubmit(e) {
        //console.log(JSON.stringify(this.state));
    e.preventDefault();
    fetch('/word/add-word', { 
      method: 'POST', 
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(this.state)
    }).then(response => {
      console.log(response);
      return response.json();
    })
    .catch(err => console.log);
  }

  
    render() {
      return (
          <form onSubmit={this.handleSubmit} >
        <div className="form-element">
          <input type="text" id="word" value={this.state.vocable} 
          onChange={this.handleWordChange} className="col-md-3 col-xs-12" placeholder="Word"/>
        </div>
        <div className="form-element">
          <textarea type="text" id="meaning" value={this.state.meaning} 
          onChange={this.handleMeaningChange} className="col-md-3 col-xs-12" placeholder="Meaning" />
        </div>
        <div className="form-element">
          <textarea type="text" id="example" value={this.state.sentence} 
          onChange={this.handleExampleChange} className="col-md-3 col-xs-12" placeholder="Example Sentence" />
        </div>
        <div className="col-md-3">
        <div className="form-actions row">
          <Button variant="warning" className="col-md-6 col-xs-3">Cancel</Button>{' '}
          <input type="submit" id="submit" className="btn btn-primary col-md-6 col-xs-3" value="Add"/>
        </div>
        </div>
      </form>
      );
    }
  }