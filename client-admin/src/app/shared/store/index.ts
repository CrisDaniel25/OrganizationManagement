// Inside the root 'index.ts' file of our store, eg - store/index.ts
import { TranslatorState } from './state/translator.state';
import { SessionState } from './state/session.state';
import { MessengerState } from './state/messenger.state';

// Still allow other modules to take what they need, eg action & selectors
export * from './state/translator.state';
export * from './state/session.state';
export * from './state/messenger.state';

export * from './action/translator.action';
export * from './action/session.action';
export * from './action/messenger.action';

// rolls up our states into one const
export const sharedStates = [
    MessengerState,
    TranslatorState,
    SessionState
];
