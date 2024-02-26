import { TestBed } from '@angular/core/testing';

import { TextDiffService } from './text-diff.service';

describe('TextDiffService', () => {
  let service: TextDiffService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TextDiffService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
