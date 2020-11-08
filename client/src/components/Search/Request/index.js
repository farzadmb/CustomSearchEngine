import React from 'react';

import EngineSelector from '../EngineSelector';
import {Border, Input, Button} from './styled';

const Request = (props) => {
    const options = ['Google'];

    return (
        <Border>
            <Input placeholder='Search Query'/>
            <Input placeholder='Link to check'/>
            <EngineSelector options={options} />
            <Button>Search</Button>
        </Border>
    );
}

export default Request;