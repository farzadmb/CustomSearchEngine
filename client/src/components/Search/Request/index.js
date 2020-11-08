import React from 'react';

import EngineSelector from '../EngineSelector';
import { Border, Input, Button } from './styled';

const Request = (props) => {
    const { query, link, engine, engines, onGetStatus, queryChangeHandler, linkChangeHandler, engineChangeHandler } = props;

    return (
        <Border>
            <Input placeholder='Search Query' text={query} onChange={(event) => { queryChangeHandler(event.target.value); }} />
            <Input placeholder='Link to check' text={link} onChange={(event) => { linkChangeHandler(event.target.value); }} />
            <EngineSelector options={engines} value={engine} onChange={(event) => { engineChangeHandler(event.target.value); }} />
            <Button onClick={onGetStatus}>Search</Button>
        </Border>
    );
}

export default Request;