import React, { Component } from 'react';

export class GetWords extends Component {
  static displayName = GetWords.name;

  constructor(props) {
    super(props);
    this.state = { words: [], loading: true };
  }

  componentDidMount() {
    this.getWords();
  }

  static renderForecastsTable(words) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Word</th>
            <th>Meaning</th>
            <th>Example</th>
          </tr>
        </thead>
        <tbody>
          {words.map(word =>
            <tr key={word.id}>
              <td>{word.vocable}</td>
              <td>{word.meaning}</td>
              <td>{word.sentence}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : GetWords.renderForecastsTable(this.state.words);

    return (
      <div>
        <h1 id="tabelLabel" >Your Vocabulary</h1>
        {contents}
      </div>
    );
  }

  async getWords() {
    const response = await fetch('word/get-words');
    const data = await response.json();
    this.setState({ words: data, loading: false });
  }
}
