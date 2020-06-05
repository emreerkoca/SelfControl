import React, { Component } from 'react';
import authHeader from '../services/AuthHeader';
import { handleResponse } from '../helpers/handleResponse';

export class GetWords extends Component {
  static displayName = GetWords.name;
 

  constructor(props) {
    super(props);
    this.state = { error: null, isLoaded: false, words: [] };
  }
  
  componentDidMount() {
    const requestOptions = {
      method: 'GET',
      headers: {
        'Authorization': authHeader()
      }
    };
  
    fetch('word/get-words?userId=' + JSON.parse(localStorage.getItem('user-info') || '{}').userId, requestOptions)
      .then(handleResponse)
      .then(
          (result) => {
            this.setState({
              isLoaded: true,
              words: result
            });
        },
        (error) => {
            this.setState({
              isLoaded: true,
              error
            });
        }
      );
  }

  static renderWordsTable(words) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Word</th>
            <th>Meaning</th>
            <th>Example</th>
            <th>Operations</th>
          </tr>
        </thead>
        <tbody>
          {words.map(word =>
            <tr key={word.id}>
              <td>{word.vocable}</td>
              <td>{word.meaning}</td>
              <td>{word.sentence}</td>
              <td>{<button className="btn btn-warning" onClick={() => GetWords.viewWord(word.id)}>View</button>}</td>
              <td>{<button className="btn btn-secondary" onClick={() => GetWords.updateWord(word.id)}>Edit</button>}</td>
              <td>{<button className="btn btn-danger" onClick={() => GetWords.deleteWord(word.id)}>Delete</button>}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  static updateWord(id) {
    console.log(id);
  }

  static viewWord(id) {
    console.log(id);
  }

  static deleteWord(id) {
    console.log(id);
  }

  render() {
    const { error, isLoaded, words } = this.state;  

    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else { 
      return (
        <div>
          { GetWords.renderWordsTable(words) }
        </div>
      );
    }
  }
}
