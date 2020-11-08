import React, { useState } from 'react';

import EngineSelector from '../EngineSelector';
import { Border, Input, Button } from './styled';

const Request = (props) => {
    const options = ['Google', 'Bing'];

    const [query, setQuery] = useState('');
    const [link, setLink] = useState('');
    const [engine, setEngine] = useState('Google');

    const queryChangeHandler = (value) => {
        setQuery(value);
        console.log('query: ', value);
    };

    const linkChangeHandler = (value) => {
        setLink(value);
        console.log('link: ', value);
    };

    const engineChangeHandler = (value) => {
        setEngine(value);
        console.log('engine: ', value);
    };

    return (
        <Border>
            <Input placeholder='Search Query' text={query} onChange={(event) => { queryChangeHandler(event.target.value); }} />
            <Input placeholder='Link to check' text={link} onChange={(event) => { linkChangeHandler(event.target.value); }} />
            <EngineSelector options={options} value={engine} onChange={(event) => { engineChangeHandler(event.target.value); }} />
            <Button>Search</Button>
        </Border>
    );
}

export default Request;