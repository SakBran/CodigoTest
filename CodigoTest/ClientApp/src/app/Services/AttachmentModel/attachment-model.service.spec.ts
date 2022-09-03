import { TestBed } from '@angular/core/testing';

import { AttachmentModelService } from './attachment-model.service';

describe('AttachmentModelService', () => {
  let service: AttachmentModelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AttachmentModelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
